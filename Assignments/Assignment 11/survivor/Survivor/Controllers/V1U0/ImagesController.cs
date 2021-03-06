﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survivor.Entities.V1U0;
using Survivor.Models;
using Survivor.Services;

namespace Survivor.Controllers.V1U0
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ImagesController : Controller
    {
        private ImageTableStorage imageTableStorage;

        private IUserNameProvider userNameProvider;

        public ImagesController(ImageTableStorage imageTableStorage, IUserNameProvider userNameProvider)
        {
            this.imageTableStorage = imageTableStorage;
            this.userNameProvider = userNameProvider;
        }

        [HttpGet]
        public async Task<IEnumerable<ImageEntity>> Get()
        {
            var results = (await imageTableStorage.GetAllImagesAsync()).Select(image => image.ToEntity());
            return results;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var imageModel = await this.imageTableStorage.GetAsync(id);

            if(imageModel == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            Response.Headers["Cache-Control"] = "25200"; // 7 hours in seconds

            Response.Headers["Location"] = this.imageTableStorage.GetDownloadUrl(id).ToString() + this.imageTableStorage.GetDownloadSas(id);

            return StatusCode((int)HttpStatusCode.TemporaryRedirect);
        }


        // POST is called when we are trying to create a new image.
        // We will return to them the upload SAS and blob URL they need to use.
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ImageEntity imageEntity)
        {
            var imageModel = await this.imageTableStorage.AddOrUpdateAsync(imageEntity.ToModel());

            var returnEntity = imageModel.ToEntity();
            returnEntity.UserName = this.userNameProvider.UserName;
            returnEntity.UploadSasToken = this.imageTableStorage.GetUploadSas(imageModel.Id);
            returnEntity.BlobUrl = imageTableStorage.GetStorageAccountBlobUrl();

            return Json(returnEntity);
        }

        [HttpPost("{id}/uploadComplete")]
        public async Task<IActionResult> UploadComplete(string id)
        {
            var imageModel = await this.imageTableStorage.GetAsync(id);

            if(imageModel == null)
            {
                return StatusCode((int)HttpStatusCode.NotFound);
            }

            imageModel.UploadComplete = true;
            await imageTableStorage.AddOrUpdateAsync(imageModel);

            return Json(imageModel.ToEntity());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (await this.imageTableStorage.DeleteAsync(id))
            {
                return StatusCode((int)HttpStatusCode.NoContent);
            }
            return StatusCode((int)HttpStatusCode.NotFound);
        }

        [HttpDelete]
        public async Task<IActionResult> Purge()
        {
            await this.imageTableStorage.PurgeAsync();
            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}

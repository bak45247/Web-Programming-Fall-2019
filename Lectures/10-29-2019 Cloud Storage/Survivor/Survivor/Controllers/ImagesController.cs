﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Survivor.Services;

namespace Survivor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly ImageTableStorage imageTableStorage;

        public ImagesController(ImageTableStorage imageTableStorage)
        {
            this.imageTableStorage = imageTableStorage;
        }

        [HttpGet]
        public string Get()
        {
            return imageTableStorage.GetUploadSas("File name would go here");
        }
    }
}

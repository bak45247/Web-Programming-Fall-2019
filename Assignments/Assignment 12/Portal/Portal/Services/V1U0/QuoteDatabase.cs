using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Services.V1U0
{
    public class QuoteDatabase
    {
        public List<string> quotes = new List<string>();
        public Random random = new Random();

        public QuoteDatabase()
        {
            quotes.Add("Hello and, again, welcome to the Aperture Science computer-aided enrichment center");
            quotes.Add("We hope your brief detention in the relaxation vault has been a pleasant one");
            quotes.Add("Your specimen has been processed and we are now ready to begin the test proper");
            quotes.Add("Before we start, however, keep in mind that although fun and learning are the primary goals of all enrichment center activities, serious injuries may occur");
            quotes.Add("Welcome to test chamber four");
            quotes.Add("Please be careful");
            quotes.Add("Make no attempt to solve it");
            quotes.Add("The Enrichment Center apologizes for this clearly broken test chamber");
            quotes.Add("Weeeeeeeeeeeeeeeeeeeeee[bzzt]");
            quotes.Add("The Enrichment Center is required to remind you that you will be baked, and then there will be cake");
            quotes.Add("[pain sound]");
        }

        public string GetQuote()
        {
            return quotes[random.Next(quotes.Count())];
        }
    }
}

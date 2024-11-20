using JobCandidateManagement.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.App.Api.Test.TestData
{
    public static class Candidate
    {
        public static CandidateInformationViewModel ValidCandidateInformation()
        {
            var candidate = new CandidateInformationViewModel
            {
                Email = "bipindhakal@gmail.com",
                FirstName = "Bipin",
                LastName = "Dhakal",
                PhoneNumber = "1234567890",
                CallTimeInterval = "2",
                LinkedInProfileUrl = "bipindhakal05",
                GitHubProfileUrl = "bipindhakal05",
                Comments = "checked for valid candidate info"
            };
            return candidate;
        }

        public static CandidateInformationViewModel InValidCandidateInformation()
        {
            var candidate = new CandidateInformationViewModel
            {
                Email = "",
                FirstName = "",
                LastName = "",
                PhoneNumber = "1234567890",
                CallTimeInterval = "2",
                LinkedInProfileUrl = "bipindhakal05",
                GitHubProfileUrl = "bipindhakal05",
                Comments = ""
            };
            return candidate;
        }

        public static CandidateInformationViewModel EmailWithRequiredField()
        {
            var candidate = new CandidateInformationViewModel
            {
                Email = "bipindhakal@gmail.com",
                FirstName = "Bipin",
                LastName = "Dhakal",
                Comments = "checked for valid candidate info"
            };
            return candidate;
        }

    }
}

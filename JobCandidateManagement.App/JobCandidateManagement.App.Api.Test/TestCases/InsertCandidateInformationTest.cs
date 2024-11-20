using JobCandidateManagement.App.Api.Test.Services;
using JobCandidateManagement.App.Api.Test.TestData;
using JobCandidateManagement.App.MediatR.MediatRService.CandidateInformationService;
using JobCandidateManagement.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.App.Api.Test.TestCases
{
    public class InsertCandidateInformationTest
    {

        [Fact]
        public async Task CreateCandidate_WithValidData_ReturnSuccess()
        {
            //Arrange
            var helper = new BaseServiceHelperTest();
            var candidateInfo = Candidate.ValidCandidateInformation();
            var command = new InsertCandidateInformationCommand(candidateInfo);

            //Act
            var result = await helper.Handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.NotNull(result.Result);
            Assert.True(result.IsSuccess);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("Saved Successfully", result.Message);
        }

        [Fact]
        public async Task CreateCandidate_MissingRequiredField_ReturnsValidationError()
        {
            //Arrange
            var helper = new BaseServiceHelperTest();
            var candidateInfo = Candidate.InValidCandidateInformation();
            var command = new InsertCandidateInformationCommand(candidateInfo);

            //Act
            var result = await helper.Handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.Null(result.Result);
            Assert.False(result.IsSuccess);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("Required field cannot be null or empty.", result.Message);
        }

        [Fact]
        public async Task CreateCandidate_NullObject_ReturnsValidationError()
        {
            //Arrange
            var helper = new BaseServiceHelperTest();
            CandidateInformationViewModel candidateInfo = null;
            var command = new InsertCandidateInformationCommand(candidateInfo);

            //Act
            var result = await helper.Handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.Null(result.Exception);
            Assert.Null(result.Result);
            Assert.False(result.IsSuccess);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
            Assert.Equal("Candidate information cannot be null.", result.Message);
        }

        [Fact]
        public void ValidateEmailInModel_ValidEmail_ReturnsNoValidationErrors()
        {
            // Arrange
            var candidateInfo = Candidate.EmailWithRequiredField();

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(candidateInfo);

            // Act
            bool isValid = Validator.TryValidateObject(candidateInfo, context, validationResults, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(validationResults);
        }


        [Fact]
        public void ValidateEmailInModel_InvalidEmail_ReturnsValidationError()
        {
            // Arrange
            var candidateInfo = Candidate.EmailWithRequiredField();
            candidateInfo.Email = "emailgmail.com";

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(candidateInfo);

            // Act
            bool isValid = Validator.TryValidateObject(candidateInfo, context, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.NotEmpty(validationResults);
            Assert.Contains(validationResults, v => v.ErrorMessage.Contains("Invalid email address"));
        }

    }
}

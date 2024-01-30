using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConvertisseurWS.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConvertisseurWS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ConvertisseurWS.Controllers.Tests
{
    [TestClass()]
    public class DevisesControllerTests
    {
        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            DevisesController controller = new DevisesController();

            // Act
            var result = controller.GetById(1);
            var actualDevise = (Devise)result.Value;

            Devise expectedDevise = new Devise
            {
                Id = 1,
                NomDevise = "Dollar",
                Taux = 1.08
            };

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult");
            Assert.IsNull(result.Result, "Erreur est pas null");
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise");


            Assert.AreEqual(expectedDevise.Id, actualDevise.Id, "Les IDs ne correspondent pas");
            Assert.AreEqual(expectedDevise.NomDevise, actualDevise.NomDevise, "Les noms ne correspondent pas");
            Assert.AreEqual(expectedDevise.Taux, actualDevise.Taux, "Les taux de change ne correspondent pas");

        }

        [TestMethod]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Arrange
            DevisesController controller = new DevisesController();

            // Act
            var result = controller.GetById(1); // Replace unknownGuid with an actual unknown GUID

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult");

            if (result != null)
            {
                // If result is not null, then proceed with assertions
                Assert.IsNull(result.Result, "Erreur est pas null");
            }
            else
            {
                // Handle the case where result is null
                Assert.Fail("Le résultat est null.");
            }
        }



        [TestMethod]
        public void GetAll_ReturnsListOfDevises()
        {
            // Arrange
            DevisesController controller = new DevisesController();

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Devise>), "Pas un IEnumerable<Devise>");

            

        }


        [TestMethod]
        public void Post_ReturnsCreatedAtRouteResult()
        {
            // Arrange
            DevisesController controller = new DevisesController();
            Devise invalidDevise = new Devise(4, "coucou", 4.0); // Invalid model with null name

            // Act
            var result = controller.Post(invalidDevise);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult");

            if (result.Result is BadRequestObjectResult badRequestObjectResult)
            {
                // If the result.Result is a BadRequestObjectResult, then the test passes
                Assert.AreEqual(StatusCodes.Status400BadRequest, badRequestObjectResult.StatusCode, "Statut incorrect");
            }
        }

        [TestMethod]
        public void Post_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            DevisesController controller = new DevisesController();
            Devise invalidDevise = new Devise(4, null, 4.0); // Invalid model with null name

            // Act
            var result = controller.Post(invalidDevise);

            // Assert
            Assert.IsInstanceOfType(result, typeof(ActionResult<Devise>), "Pas un ActionResult");

            if (result.Result is BadRequestObjectResult badRequestObjectResult)
            {
                // If the result.Result is a BadRequestObjectResult, then the test passes
                Assert.AreEqual(StatusCodes.Status400BadRequest, badRequestObjectResult.StatusCode, "Statut incorrect");
            }
            else
            {
                // If the result.Result is not a BadRequestObjectResult, the test fails
                Assert.Fail("Le résultat n'est pas un BadRequestObjectResult.");
            }
        }
        [TestMethod]
        public void Put_InvalidModel_ReturnsBadRequest()
        {
            // Arrange
            DevisesController controller = new DevisesController();
            Devise invalidDevise = new Devise(/* Set the properties of the invalid Devise object */);

            // Act
            var result = controller.Put(1, invalidDevise); // Assuming ID = 1 exists in the list

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult), "Pas un BadRequestObjectResult");
        }





    }
}
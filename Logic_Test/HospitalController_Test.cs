using DataLayer.Entities;
using DataLayer.Repository.Interfaces;
using DataLayer.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApiAPP.Controllers;

namespace Logic_Test
{
    [TestClass]
    public class HospitalController_Test
    {
        private HospitalController _hospitalController;
        private Mock<IHospitalRepository> _repositoryMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<IHospitalRepository>();
            _hospitalController = new HospitalController(_repositoryMock.Object);
        }

        [TestMethod()]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _repositoryMock.Setup(repository => repository.Create(It.IsAny<Hospital>())).Verifiable();
            var result = _hospitalController.Create(new HospitalRequest() {Name = "test"});
            _repositoryMock.Verify(repository => repository.Create(It.IsAny<Hospital>()), Times.AtLeastOnce());
        }
    }
}

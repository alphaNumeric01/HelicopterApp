namespace ShipmentCheckerUnitTests
{
    [TestClass]
    public class UnitTests
    {
        ShipmentCheckerApp.Program app = new ShipmentCheckerApp.Program();

        [TestMethod]
        public void KnownUnitTests()
        {
            Assert.IsTrue(app.checkIfDeliverable(230, 300, 250, 20), "Known Unit Test 1 error");
            Assert.IsFalse(app.checkIfDeliverable(230, 300, 250, 100), "Known Unit Test 2 error");
            Assert.IsTrue(app.checkIfDeliverable(40, 400, 150, 9), "Known Unit Test 3 error");
            Assert.IsFalse(app.checkIfDeliverable(230, 400, 450, 40), "Known Unit test 4 error");
        }

        [TestMethod]
        public void FailWhenInvalidFuelTests()
        {
            Assert.IsFalse(app.checkIfDeliverable(250, 300, 250, 20), "Over Max Fuel Unit Test error");
            Assert.IsFalse(app.checkIfDeliverable(-1, 300, 250, 20), "Negative Fuel Unit Test error");
        }

        [TestMethod]
        public void FailWhenInvalidSizeTests()
        {
            Assert.IsFalse(app.checkIfDeliverable(230, -5, 250, 20), "Negative Size Test Fail error");
            Assert.IsFalse(app.checkIfDeliverable(230, 1005, 250, 20), "Beyond Max Size Test error");
        }

        [TestMethod]
        public void FailWhenWeightTests()
        {
            Assert.IsFalse(app.checkIfDeliverable(230, 300, -293, 20), "Negative Weight Test Fail error");
            Assert.IsFalse(app.checkIfDeliverable(230, 300, 600, 20), "Beyond max weight Test Fail error");
        }

        [TestMethod]
        public void CheckWinchTests()
        {
            Assert.IsTrue(app.checkIfDeliverable(230, 301, 400, 20), "Winch Present Pass Test error");
            Assert.IsTrue(app.checkIfDeliverable(230, 300, 500, 20), "Winch Missing Pass Test error");
            Assert.IsFalse(app.checkIfDeliverable(230, 301, 401, 20), "Winch Present Fail Test 2 error");
            Assert.IsFalse(app.checkIfDeliverable(230, 300, 501, 20), "Winch Missing Fail Test 2 error");
        }

        [TestMethod]
        public void CheckDistanceTests()
        {
            Assert.IsTrue(app.checkIfDeliverable(200, 872, 200, 10), "Distance Pass Test error");
            Assert.IsFalse(app.checkIfDeliverable(100, 353, 800, 21), "Distance Fail Test error");
        }
    }
}
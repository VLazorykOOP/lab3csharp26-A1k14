using LabWork3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using static LabWork3.ATriangle;

namespace TestLab3
{
    [TestClass]
    public class ATriangleTests
    {
        [TestMethod]
        public void GetArea_ValidSides_ReturnsCorrectArea()
        {
            ATriangle triangle = new ATriangle(3, 4, 1);

            double expectedArea = 6.0;
            double actualArea = triangle.GetArea();

            Assert.AreEqual(expectedArea, actualArea, 0.001);
        }

        [TestMethod]
        public void GetPerimeter_ValidSides_ReturnsCorrectPerimeter()
        {
            ATriangle triangle = new ATriangle(3, 4, 1);

            double expectedPerimeter = 12.0;
            double actualPerimeter = triangle.GetPerimeter();

            Assert.AreEqual(expectedPerimeter, actualPerimeter, 0.001);
        }

        [TestMethod]
        public void IsIsosceles_EqualSides_ReturnsTrue()
        {
            ATriangle triangle = new ATriangle(5, 5, 2);

            bool isIsosceles = triangle.IsIsosceles();

            Assert.IsTrue(isIsosceles);
        }

        [TestMethod]
        public void IsIsosceles_DifferentSides_ReturnsFalse()
        {
            ATriangle triangle = new ATriangle(3, 4, 2);

            bool isIsosceles = triangle.IsIsosceles();

            Assert.IsFalse(isIsosceles);
        }

        [TestMethod]
        public void PropertyA_SetNegativeValue_IgnoresChange()
        {
            ATriangle triangle = new ATriangle(3, 4, 1);

            triangle.A = -10;

            Assert.AreEqual(3, triangle.A);
        }
    }

    [TestClass]
    public class HierarchyTests
    {
        [TestMethod]
        public void Mechanism_InheritsFromProductAndAssembly()
        {
            Mechanism mechanism = new Mechanism("Гідроциліндр", 25.0, 8, "Лінійне переміщення");

            Assert.IsInstanceOfType(mechanism, typeof(System.Reflection.Assembly));
            Assert.IsInstanceOfType(mechanism, typeof(Product));
        }
    }
}
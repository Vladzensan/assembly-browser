using AssemblyBrowser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssemblyBrowserTester
{
    [TestClass]
    public class UnitTest
    {
        string _firstTestPath = @"C:\Users\Vladzensan\Desktop\MPP-Lab-3-master\AssemblyBrowser\bin\Debug\netcoreapp3.1\AssemblyBrowser.dll";

        string _secondTestPath = @"C:\Users\Vladzensan\Desktop\MPP-Lab-3-master\ExtensionMethodTest\bin\Debug\netcoreapp3.1\ExtensionMethodTest.dll";

        [TestMethod]
        public void ExtensionMethodTest()
        {
            AssemblyBrowser.AssemblyBrowser assemblyBrowser = new AssemblyBrowser.AssemblyBrowser(_secondTestPath);
            var assemblyData = assemblyBrowser.assemblyData;
            NameSpaceData nameSpaceData = null;
            assemblyData.NameSpaces.TryGetValue("ExtensionMethodTest", out nameSpaceData);
            Assert.AreEqual("GetExtension", nameSpaceData.TypesList[1].Methods[nameSpaceData.TypesList[1].Methods.Count - 1].Name);
        }

        [TestMethod]
        public void SeveralNameSpacesTestMethod()
        {
            AssemblyBrowser.AssemblyBrowser assemblyBrowser = new AssemblyBrowser.AssemblyBrowser(_secondTestPath);
            var assemblyData = assemblyBrowser.assemblyData;
            Assert.AreEqual(2, assemblyData.NameSpaces.Count);
        }

        [TestMethod]
        public void PositiveTestMethod()
        {
            AssemblyBrowser.AssemblyBrowser assemblyBrowser = new AssemblyBrowser.AssemblyBrowser(_firstTestPath);
            var assemblyData = assemblyBrowser.assemblyData;
            Assert.AreEqual(1, assemblyData.NameSpaces.Values.Count);
            NameSpaceData nameSpaceData = null; 
            assemblyData.NameSpaces.TryGetValue("AssemblyBrowser", out nameSpaceData);
            Assert.AreEqual(7, nameSpaceData.TypesList.Count);
            Assert.IsTrue(assemblyData.NameSpaces.ContainsKey("AssemblyBrowser"));
            Assert.AreEqual(1, nameSpaceData.TypesList[1].Properties.Count);
        }
    }
}

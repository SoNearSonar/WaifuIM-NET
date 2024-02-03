using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WaifuIM.Web.Models;

namespace WaifuIM.Web.Tests
{
    [TestClass]
    public class WaifuIMClientTest
    {
        private readonly string _token = "";

        [TestMethod]
        public void TestGetImages_ValidApiKey_NoSettings_ReturnsImageList()
        {
            WaifuIMClient client = new WaifuIMClient(_token);
            List<WaifuImage> images = client.GetImages().Result;

            Assert.IsNotNull(images);
            Assert.IsTrue(images.Count > 0);
            Assert.IsTrue(images[0].ImageId != 0);
        }

        [TestMethod]
        public void TestGetImages_ValidApiKey_AddedSettings_ReturnsImageList()
        {
            WaifuIMClient client = new WaifuIMClient(_token);

            SearchSettings searchSettings = new SearchSettings()
            {
                OnlyGif = false,
                Orientation = WaifuImageOrientation.Landscape,
                IsNsfw = false,
                IncludedTags = new WaifuTag[] { WaifuTag.Maid, WaifuTag.Oppai }
            };

            List<WaifuImage> images = client.GetImages(searchSettings).Result;

            Assert.IsNotNull(images);
            Assert.IsTrue(images.Count > 0);
            Assert.IsTrue(images[0].ImageId != 0);
        }

        [TestMethod]
        public void TestGetImages_NoApiKey_NoSettings_ReturnsImageList()
        {
            WaifuIMClient client = new WaifuIMClient();
            List<WaifuImage> images = client.GetImages().Result;

            Assert.IsNotNull(images);
            Assert.IsTrue(images.Count > 0);
            Assert.IsTrue(images[0].ImageId != 0);
        }

        [TestMethod]
        public void TestGetImages_NoApiKey_AddedSettings_ReturnsImageList()
        {
            WaifuIMClient client = new WaifuIMClient();

            SearchSettings searchSettings = new SearchSettings()
            {
                OnlyGif = false,
                Orientation = WaifuImageOrientation.Landscape,
                IsNsfw = false,
                IncludedTags = new WaifuTag[] { WaifuTag.Maid, WaifuTag.Oppai }
            };

            List<WaifuImage> images = client.GetImages(searchSettings).Result;

            Assert.IsNotNull(images);
            Assert.IsTrue(images.Count > 0);
            Assert.IsTrue(images[0].ImageId != 0);
        }
    }
}

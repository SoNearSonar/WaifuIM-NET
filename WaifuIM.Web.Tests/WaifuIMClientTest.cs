using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        [TestMethod]
        public void TestGetFavoriteImages_ValidApiKey_NoSettings_ReturnsImageList()
        {
            WaifuIMClient client = new WaifuIMClient(_token);
            List<WaifuImage> images = client.GetFavoriteImages().Result;

            Assert.IsNotNull(images);
            Assert.IsTrue(images.Count > 0);
            Assert.IsTrue(images[0].ImageId != 0);
        }

        [TestMethod]
        public void TestGetFavoriteImages_ValidApiKey_AddedSettings_ReturnsImageList()
        {
            WaifuIMClient client = new WaifuIMClient(_token);

            SearchSettings searchSettings = new SearchSettings()
            {
                OnlyGif = false,
                Orientation = WaifuImageOrientation.Landscape,
                IsNsfw = false,
                IncludedTags = new WaifuTag[] { WaifuTag.Maid, WaifuTag.Oppai }
            };

            List<WaifuImage> images = client.GetFavoriteImages(searchSettings).Result;

            Assert.IsNotNull(images);
            Assert.IsTrue(images.Count > 0);
            Assert.IsTrue(images[0].ImageId != 0);
        }

        [TestMethod]
        public void TestGetFavoriteImages_NoApiKey_NoSettings_ReturnsImageList()
        {
            WaifuIMClient client = new WaifuIMClient();

            try
            {
                List<WaifuImage> images = client.GetFavoriteImages().Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsInstanceOfType(ex.InnerException, typeof(HttpRequestException));
            }
        }

        [TestMethod]
        public void TestGetFavoriteImages_NoApiKey_AddedSettings_ReturnsError()
        {
            WaifuIMClient client = new WaifuIMClient();

            SearchSettings searchSettings = new SearchSettings()
            {
                OnlyGif = false,
                Orientation = WaifuImageOrientation.Landscape,
                IsNsfw = false,
                IncludedTags = new WaifuTag[] { WaifuTag.Maid, WaifuTag.Oppai }
            };

            try
            {
                List<WaifuImage> images = client.GetFavoriteImages(searchSettings).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException ex) 
            {
                Assert.IsInstanceOfType(ex.InnerException, typeof(HttpRequestException));
            }
        }

        [TestMethod]
        public void TestInsertFavoriteImage_ValidApiKey_GivenData_ReturnsFavoriteStatus()
        {
            WaifuIMClient client = new WaifuIMClient(_token);
            WaifuFavoriteStatus status = client.InsertFavoriteImage(4565).Result;

            Assert.IsTrue(status == WaifuFavoriteStatus.Inserted);
        }

        [TestMethod]
        public void TestInsertFavoriteImage_NoApiKey_ReturnsError()
        {
            WaifuIMClient client = new WaifuIMClient();

            try
            {
                WaifuFavoriteStatus status = client.InsertFavoriteImage(4565).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsInstanceOfType(ex.InnerException, typeof(HttpRequestException));
            }
        }

        [TestMethod]
        public void TestDeleteFavoriteImage_ValidApiKey_GivenData_ReturnsFavoriteStatus()
        {
            WaifuIMClient client = new WaifuIMClient(_token);
            WaifuFavoriteStatus status = client.DeleteFavoriteImage(4565).Result;

            Assert.IsTrue(status == WaifuFavoriteStatus.Deleted);
        }

        [TestMethod]
        public void TestDeleteFavoriteImage_NoApiKey_ReturnsError()
        {
            WaifuIMClient client = new WaifuIMClient();

            try
            {
                WaifuFavoriteStatus status = client.DeleteFavoriteImage(4565).Result;
                Assert.Fail("Test case should not go here");
            }
            catch (AggregateException ex)
            {
                Assert.IsInstanceOfType(ex.InnerException, typeof(HttpRequestException));
            }
        }
    }
}

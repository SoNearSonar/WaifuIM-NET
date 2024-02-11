# Using WaifuIM-NET
This project is a API wrapper for WaifuIM's web API. It supports the following functions:
- Getting images.
- Getting tags.
- Getting full tags.
- Inserting, deleting, toggling, and getting favorite images.
- Reporting images.

Notes:
- A token is required for you to use the favorite and reporting image calls, you can get one [here](https://www.waifu.im/dashboard/) and you must login using Discord

Below are examples of calls you can make with this client.

# Images
## Getting images with search filtering

```csharp
// Arrange
var client = new WaifuIMClient();
var searchSettings = new SearchSettings()
{
    OnlyGif = false,
    Orientation = WaifuImageOrientation.Landscape,
    IsNsfw = false,
    IncludedTags = new WaifuTag[] { WaifuTag.Maid, WaifuTag.Oppai }
};

// Act
var images = client.GetImages(searchSettings).Result;

// Assert
Assert.IsNotNull(images);
Assert.IsTrue(images.Count > 0);
Assert.IsTrue(images[0].ImageId != 0);
```

## Getting full tag information
Note: Tags can be either safe for work (SFW) or not safe for work (NSFW)
```csharp
// Arrange
var client = new WaifuIMClient();

// Act
var list = client.GetFullTags().Result;

// Assert
Assert.IsNotNull(list);
Assert.IsTrue(list.VersatileTags.Length > 0);
Assert.IsTrue(list.NsfwTags.Length > 0);
```

## Getting all favorited images
```csharp
// Arrange
var token = "token";
var client = new WaifuIMClient(token);

// Act
var images = client.GetFavoriteImages().Result;

// Assert
Assert.IsNotNull(images);
Assert.IsTrue(images.Count > 0);
Assert.IsTrue(images[0].ImageId != 0);
```

## Adding a favorite image
Note: This method throws a HttpRequestException (wrapped in a AggregateException) if the image ID you want to favorite already is favorited
```csharp
// Arrange
var token = "token";
var client = new WaifuIMClient(token);

// Act
var status = client.InsertFavoriteImage(4565).Result;

// Assert
Assert.IsTrue(status == WaifuFavoriteStatus.Inserted);
```

## Deleting a favorite image
Note: This method throws a HttpRequestException (wrapped in a AggregateException) if the image ID you want to unfavorite already is unfavorited
```csharp
// Arrange
var token = "token";
var client = new WaifuIMClient(token);

// Act
var status = client.DeleteFavoriteImage(4565).Result;

// Assert
Assert.IsTrue(status == WaifuFavoriteStatus.Inserted);
```

## Toggling a favorite image
Note: This method either adds or removes a favorite image from your account depending if it is vice versa
```csharp
// Arrange
var token = "token";
var client = new WaifuIMClient(token);

// Act
var status = client.ToggleFavoriteImage(4565).Result;

// Assert
Assert.IsTrue(status == WaifuFavoriteStatus.Inserted);
```
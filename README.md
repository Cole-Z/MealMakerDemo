# MealApiDemo

## Meal maker (not for commercial use)

Meal Maker is a meal creator tool that will send requests to 'TheMealDB' and respond with the Meal name, image, YouTube link for instructions, a list of ingredients and more.

The functionality is minimal, but as of now users can search by category, name or generate a random meal.

To get started, clone the repo:
```
git clone https://github.com/Cole-Z/MealMakerDemo.git

```

Then CD into the MealApiDemo folder:
```
$ cd MealApiDemo
```

Finally, run dotnet build and run to open the project:
```
dotnet build
```
```
dotnet run
```
## Application on open

![image](https://github.com/Cole-Z/MealMakerDemo/assets/98670265/a6a93987-6807-4906-8e1f-0f893fa00280)

Menu is shown on lower part of screen. 

Example: To narrow down searches, try starting with a category from this list, then you will be able to get a full list of Meal names you can search for. If a meal is not in the DB, nothing will be returned.


![image](https://github.com/Cole-Z/MealMakerDemo/assets/98670265/2c838624-6348-424c-8f6a-9be61913900e)

Results of categories being searched.

Next, we can filter down even more by search by a name from the previous category listing.

![image](https://github.com/Cole-Z/MealMakerDemo/assets/98670265/2784bcae-6bca-4723-9e02-4a19c85bb6d8)


## NOT FOR COMMERCIAL USE

All data and information is provided from The Meal DB. You can find more information in their docs for more customizations around their API as well as getting an upgraded key for production. 


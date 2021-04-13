##### Form Tag Helpers

```c#
<form asp-controller="room" asp-action="book">

   ...

</form>
```



##### Input Tag Helpers

`asp-for`

```c#
<div class="form-group">
    <label class="col-md-4 control-label" asp-for="Title"></label>  
    <div class="col-md-4">
        <input class="form-control input-lg" asp-for="Title">
    </div>
</div>
```

##### Validation Tag Helpers

```c#
<span asp-validation-for="Email"></span>
    
<div asp-validation-summary="All"></span>
```

##### Select List Tag Helpers

```c#
<select id="room" name="room" class="form-control"
        asp-for="@Model.CurrentRoomType"
        asp-items="@Html.GetEnumSelectList(typeof(RoomCategories))">
</select>
```

##### Implementing the Tag Helper
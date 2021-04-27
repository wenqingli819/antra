# Navigation emit by an event

![image-20210420163736203](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210420163736203.png)emit an event that allow us to determine which component should be displayed.

```html
<!-- app.component.html --> 
<app-header (featureSelected) = "onNavigate($event)"></app-header>
<div class="container">
  <div class="row">
    <div class="col-md-12">
      <app-recipes *ngIf="loadedFeature ==='recipe'"></app-recipes>
      <app-shopping-list *ngIf="loadedFeature !=='recipe'"></app-shopping-list>
    </div>
  </div>
</div>

```

![image-20210420153303327](../../../../../../../../Desktop/ShareToMac/code-workspace/typora/antra/resources/image-20210420153303327.png)

```typescript
HeaderComonent{
	@Output() featureSelected = new EventEmitter<string>();//string is the feature we selected in html
	
    // emit an event when we click the button
	onSelect(feature:string){
	this.featureSelected.emit(feature);
	}
}
```

```
AppComponent{
	loadedFeature = 'recipe';
	
	onNavigate(feature:string){
		this.loadedFeature = feature;
	}
}
```


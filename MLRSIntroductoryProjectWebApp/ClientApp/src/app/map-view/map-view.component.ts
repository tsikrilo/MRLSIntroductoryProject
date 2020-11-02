import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from "@angular/core";
import { loadModules } from "esri-loader";
import esri = __esri;

@Component({
  selector: "app-esri-map",
  templateUrl: "./map-view.component.html",
  styleUrls: ["./map-view.component.css"]
})
export class MapViewComponent implements OnInit, OnDestroy {

  @ViewChild("mapView", { static: true }) private mapViewElement: ElementRef;

  private _esriMapView: esri.MapView;

  async ngOnInit() {
    try {
      const [EsriMap, EsriMapView] = await loadModules([
        "esri/Map",
        "esri/views/MapView"
      ]);

      const mapProp: esri.MapProperties = {
        basemap: "streets"
      };

      const esriMap: esri.Map = new EsriMap(mapProp);

      const mapViewProperties: esri.MapViewProperties = {
        container: this.mapViewElement.nativeElement,
        center: [14.5146, 35.8989],
        zoom: 15,
        map: esriMap
      };

      this._esriMapView = new EsriMapView(mapViewProperties);
      await this._esriMapView.when();
      return this._esriMapView;
    } catch (error) {
      console.log("Error initialing esri map: ", error);
    }
  }

  ngOnDestroy() {
    if (this._esriMapView) {
      this._esriMapView.container = null;
    }
  }
}

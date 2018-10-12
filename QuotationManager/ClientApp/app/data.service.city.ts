import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataServiceCity {

    private url = "/api/cities";

    constructor(private http: HttpClient) {
    }

    getCities() {
        return this.http.get(this.url);
    }
}
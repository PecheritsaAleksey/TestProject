import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataServicePurpose {

    private url = "/api/purposes";

    constructor(private http: HttpClient) {
    }

    getPurposes() {
        return this.http.get(this.url);
    }
}
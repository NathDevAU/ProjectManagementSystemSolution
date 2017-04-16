import { Component } from '@angular/core';
import { Http } from '@angular/http';
@Component({
    selector: 'people',
    template: require('./personlist.component.html')

})
export class PeopleComponent {
    public people: Person[];
    constructor(http: Http) {
        http.get('api/PersonData/GetPersonList').subscribe(result => {
            //  debugger;
            this.people = result.json() as Person[];
        });
        //        this.project = { ProjectID: 1, ProjectName: "Sample Project 1", ProjectDesc : "This is sample project" };
    }
}
interface Person {
    personID: number;
    firstName: string;
    lastName: string;


}
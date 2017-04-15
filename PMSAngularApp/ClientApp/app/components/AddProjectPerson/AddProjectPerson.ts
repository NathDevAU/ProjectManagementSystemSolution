import { OnInit,  Component } from '@angular/core';
import { Router, ActivatedRoute, Params } from '@angular/router';
import { Http } from '@angular/http';

@Component({
    selector: 'AddProjectPerson',
    template: require('./AddProjectPerson.html')
})
export class AddProjectPersonComponent implements OnInit {
    public Persons: Person[];
    constructor(http: Http, private activatedRoute: ActivatedRoute) {

        http.get('api/GetPersonList').subscribe(result => {
            this.Persons = result.json() as Person[];
        });
    }
    ngOnInit() {
        // subscribe to router event
        this.activatedRoute.params.subscribe((params: Params) => {
            let ProjectName = params[1];
            let ProjectID = params[0];
            console.log(ProjectName);
        });
    }

}

interface Person
{
    firstName: string;
    lastName: string;
    personPosition: string;
    personMobile: string
}
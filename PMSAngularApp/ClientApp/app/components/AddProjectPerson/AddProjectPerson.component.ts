import { OnInit, OnDestroy,  Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';

@Component({
    selector: 'AddProjectPerson',
    template: require('./AddProjectPerson.component.html')
})
export class AddProjectPersonComponent  {
    public Persons: Person[];
    public ProjectID : number;
    public ProjectName: string;
    constructor(http: Http, private route: ActivatedRoute, private router : Router) {

        http.get('api/GetPersonList').subscribe(result => {
            this.Persons = result.json() as Person[];
        });
    }
    ngOnInit() {
        this.route
            .queryParams
            .subscribe(params => {
                
                // Defaults to 0 if no query param provided.
                this.ProjectID = params['ProjectID'];
                this.ProjectName = params['ProjectName'];
            });
    }
    ngOnDestroy() {
       
    }
}

interface Person
{
    firstName: string;
    lastName: string;
    personPosition: string;
    personMobile: string
}
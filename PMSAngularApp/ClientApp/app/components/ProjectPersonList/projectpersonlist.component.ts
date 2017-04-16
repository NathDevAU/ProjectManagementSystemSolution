import { OnInit, OnDestroy, Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http, Headers, RequestOptions } from '@angular/http';


@Component({
    selector: 'ViewProjectPersons',
    template: require('./projectpersonlist.component.html')
})
export class ProjectPersonListComponent {
    public ProjectPersons: ProjectPerson[];
    public ProjectID: number;
    public ProjectName: string;
    public PostURL: string;
    public httpService: Http;

    constructor(http: Http, private route: ActivatedRoute, private router: Router) {
        this.httpService = http;
    }
    ngOnInit() {
        this.route
            .queryParams
            .subscribe(params => {

                // Defaults to 0 if no query param provided.
                this.ProjectID = parseInt(params['ProjectID']);
                this.ProjectName = params['ProjectName'];
                debugger;
                this.httpService.get('api/ProjectPersonData/GetProjectPersonList?ProjectID=' + this.ProjectID).subscribe(result => {
                    debugger;
                    this.ProjectPersons = result.json() as ProjectPerson[];
                });
            });
    }
    ngOnDestroy() {

    }

    
}

interface ProjectPerson {
    personID: number;
    firstName: string;
    lastName: string;
   
}
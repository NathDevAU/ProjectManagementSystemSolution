import { OnInit, OnDestroy,  Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Http, Headers, RequestOptions  } from '@angular/http';


@Component({
    selector: 'AddProjectPerson',
    template: require('./AddProjectPerson.component.html')
})
export class AddProjectPersonComponent  {
    public Persons: Person[];
    public ProjectID : number;
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
                this.ProjectID = parseInt( params['ProjectID']);
                this.ProjectName = params['ProjectName'];
                this.httpService.get('api/PersonData/GetPersonListToAddInProject?ProjectID=' + this.ProjectID).subscribe(result => {
                    // debugger;
                    this.Persons = result.json() as Person[];
                });
            });
    }
    ngOnDestroy() {
       
    }

    //Person need to be added into selected Project
    PersonSelected(personIDSelected, projectIDSelected)
    {
        let headersB = new Headers();
        headersB.append('Content-Type', 'application/json');
        //let options = new RequestOptions({ headers: headersB }); 
        let options = new RequestOptions({ headers: headersB });
        alert(personIDSelected);
        alert(projectIDSelected);
       
        var body = JSON.stringify({ PersonID: personIDSelected, ProjectID: projectIDSelected });
        debugger;
              this.httpService.post('api/ProjectPersonData/PostPersonToProject', body, options).subscribe(result => {
            // debugger;
           

        });
    }
}

interface Person
{
    personID: number;
    firstName: string;
    lastName: string;
    mobileNo: string
}
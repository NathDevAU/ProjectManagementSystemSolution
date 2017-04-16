import { Component } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
@Component({
    selector: 'AddProject',
    template: require('./addproject.component.html')
})
export class AddProjectComponent
{
    public Project: Project;
    public httpService: Http;
    constructor(http: Http) {
        this.httpService = http;
    }

    AddNewProject(projectName:string, projectDesc:string)
    {
        alert(projectDesc);
        let headersB = new Headers();
        headersB.append('Content-Type', 'application/json');
        //let options = new RequestOptions({ headers: headersB }); 
        let options = new RequestOptions({ headers: headersB });
        var body = JSON.stringify({ ProjectID: 0, ProjectName: projectName, ProjectDesc: projectDesc});
        debugger;
        this.httpService.post('api/ProjectsData/PostProject', body, options).subscribe(result => {
            // debugger;


        });
    }
}
interface Project
{
    ProjectID: number;
    ProjectName: string;
    ProjectDesc: string;

}
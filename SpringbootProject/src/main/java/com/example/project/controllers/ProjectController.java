/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers;

import com.example.project.entities.Projects;
import com.example.project.services.ProjectService;
import java.util.List;
import java.util.Optional;
import javax.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

/**
 *
 * @author vuchu
 */
@RestController
public class ProjectController {
    
    @Autowired
    ProjectService service;   
    
    public ProjectController(ProjectService service){
        this.service = service;
    }
    @RequestMapping(value = "/projects", method = RequestMethod.GET)
    public List<Projects> findAll() {
        List<Projects> listAll = service.findAll();
            return listAll;
    }
    
    @PostMapping(value = "/projects")
    public ResponseEntity<Projects> createOrUpdate(@Valid @RequestBody Projects pro) {
        try {
            Projects updated = service.createOrUpdateProjects(pro);
            return new ResponseEntity<Projects>(updated, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Create Failed", e);
        }

    }
    
    @DeleteMapping(value = "/projects/{id}")
    public HttpStatus deleteById(@PathVariable("id") int proid) {
        try{
            service.deleteProjectsById(proid);
            return HttpStatus.FORBIDDEN;
        }catch(Exception e){
            throw new ResponseStatusException(HttpStatus.BAD_GATEWAY, "Delete Failed", e);
        }
        
    }
    
    
//    @GetMapping(value = "/projects/search/{search}")
//    public ResponseEntity<List<Projects>> search(@PathVariable("search") String search) {
//        try{
//            List<Projects> project = service.findProjects(search);
//            if (project != null) {
//                return new ResponseEntity<List<Projects>>(project, new HttpHeaders(), HttpStatus.OK);
//            } else {
//                return new ResponseEntity<List<Projects>>(null, new HttpHeaders(), HttpStatus.NOT_FOUND);
//            }
//        }catch(Exception e){
//            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Value Not Found", e);
//        }
//        
//    }
    
    @RequestMapping(value = "/projects/{id}", method = RequestMethod.GET)
    public ResponseEntity<Optional<Projects>> getPCostByID(@PathVariable("id") int pid) {
        try {
            Optional<Projects> list = service.findById(pid);
            if (list != null) {
                return new ResponseEntity<Optional<Projects>>(list, new HttpHeaders(), HttpStatus.OK);
            } else {
                return new ResponseEntity<Optional<Projects>>(null, new HttpHeaders(), HttpStatus.NOT_FOUND);
            }
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Invalid Project Id", e);
        }
    }
}

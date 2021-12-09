/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers;

import com.example.project.entities.Groups;
import com.example.project.services.GroupService;
import java.util.ArrayList;
import java.util.List;
import javax.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.server.ResponseStatusException;

/**
 *
 * @author vuman
 */
@Controller
public class GroupController {
    
    @Autowired
    GroupService service;   
    
    public GroupController(GroupService service){
        this.service = service;
    }
    @GetMapping(value = "/groups", produces = "application/json")    
    public ResponseEntity<List<Groups>> findAll() {
        try {
            List<Groups> list = new ArrayList<>();
            list = service.findAllGroup();

            return new ResponseEntity<List<Groups>>(list, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Groups Not Found", e);
        }

    }
    
    @PostMapping(value = "/groups")
    public ResponseEntity<Groups> createOrUpdate(@Valid @RequestBody Groups group) {
        try {
            Groups updated = service.createAndupdateGroup(group);
            return new ResponseEntity<Groups>(updated, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Create Failed", e);
        }

    }
    
    @DeleteMapping(value = "/groups/{id}")
    public HttpStatus deleteDocumentById(@PathVariable("id") int gid) {
        try{
            service.deleteGroupByID(gid);
            return HttpStatus.FORBIDDEN;
        }catch(Exception e){
            throw new ResponseStatusException(HttpStatus.BAD_GATEWAY, "Delete Failed", e);
        }
        
    }
    
}

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers;

import com.example.project.entities.Documents;
import com.example.project.services.DocumentService;
import java.util.ArrayList;
import java.util.List;
import javax.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

/**
 *
 * @author vuchu
 */
@RestController
public class DocumentController {
    @Autowired
    DocumentService service;   
    
    public DocumentController(DocumentService service){
        this.service = service;
    }
    @GetMapping(value = "/documents", produces = "application/json")    
    public ResponseEntity<List<Documents>> findAll() {
        try {
            List<Documents> list = new ArrayList<>();
            list = service.findAll();

            return new ResponseEntity<List<Documents>>(list, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Employees Not Found", e);
        }
    }    
    
    
    @PostMapping(value = "/documents")
    public ResponseEntity<Documents> createOrUpdate(@Valid @RequestBody Documents doc) {
        try {
            Documents updated = service.createOrUpdateDocuments(doc);
            return new ResponseEntity<Documents>(updated, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Create Failed", e);
        }

    }
    
    @DeleteMapping(value = "/documents/{id}")
    public HttpStatus deleteDocumentById(@PathVariable("id") int docid) {
        try{
            service.deleteDocumentsById(docid);
            return HttpStatus.FORBIDDEN;
        }catch(Exception e){
            throw new ResponseStatusException(HttpStatus.BAD_GATEWAY, "Delete Failed", e);
        }
        
    }
    
//    }
}
    
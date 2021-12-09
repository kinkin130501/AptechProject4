/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers;

import com.example.project.entities.Request;
import com.example.project.services.RequestService;
import java.util.List;
import java.util.Optional;
import javax.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

/**
 *
 * @author vuman
 */
@RestController
public class RequestController {
    
    @Autowired
    RequestService service;   
    
    public RequestController(RequestService service){
        this.service = service;
    }
    @RequestMapping(value = "/requests", method = RequestMethod.GET)
    public List<Request> findAll() {
        List<Request> listAll = service.findAll();
            return listAll;
    }
    
    @PostMapping(value = "/requests")
    public ResponseEntity<Request> createOrUpdate(@Valid @RequestBody Request rq) {
        try {
            Request updated = service.createOrUpdateRequest(rq);
            return new ResponseEntity<Request>(updated, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Create Failed", e);
        }

    }
    
    @DeleteMapping(value = "/requests/{id}")
    public HttpStatus deleteAccountById(@PathVariable("id") int rqid) {
        try{
            service.deleteById(rqid);
            return HttpStatus.FORBIDDEN;
        }catch(Exception e){
            throw new ResponseStatusException(HttpStatus.BAD_GATEWAY, "Delete Failed", e);
        }
        
    }
    
    @RequestMapping(value = "/requests/{id}", method = RequestMethod.GET)
    public ResponseEntity<Optional<Request>> getPCostByID(@PathVariable("id") int rid) {
        try {
            Optional<Request> list = service.findById(rid);
            if (list != null) {
                return new ResponseEntity<Optional<Request>>(list, new HttpHeaders(), HttpStatus.OK);
            } else {
                return new ResponseEntity<Optional<Request>>(null, new HttpHeaders(), HttpStatus.NOT_FOUND);
            }
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Invalid Request Id", e);
        }
    }
}
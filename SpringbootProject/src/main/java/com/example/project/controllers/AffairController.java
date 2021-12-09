/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers;

import com.example.project.entities.Affairs;
import com.example.project.services.AffairService;
import java.util.ArrayList;
import java.util.List;
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
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

/**
 *
 * @author vuchu
 */
@RestController
public class AffairController {
    
    @Autowired
    AffairService service;   
    
    public AffairController(AffairService service){
        this.service = service;
    }
    @GetMapping(value = "/affairs")
    public ResponseEntity<List<Affairs>> getAll() {
        try {
            List<Affairs> list = new ArrayList<>();
            list = service.findAll();
            return new ResponseEntity<List<Affairs>>(list, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Employees Not Found", e);
        }

    }
    
    @PostMapping(value = "/affairs")
    public ResponseEntity<Affairs> createOrUpdate(@Valid @RequestBody Affairs aff) {
        try {
            Affairs updated = service.createOrUpdateAffairs(aff);
            return new ResponseEntity<Affairs>(updated, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Create Failed", e);
        }

    }
    
    @DeleteMapping(value = "/affairs/{id}")
    public HttpStatus deleteAffairById(@PathVariable("id") int affid) {
        try{
            service.deleteAffairsById(affid);
            return HttpStatus.FORBIDDEN;
        }catch(Exception e){
            throw new ResponseStatusException(HttpStatus.BAD_GATEWAY, "Delete Failed", e);
        }
        
    }
    
    
//    @GetMapping(value = "/affairs/search/{search}")
//    public ResponseEntity<List<Affairs>> search(@PathVariable("search") String search) {
//        try{
//            List<Affairs> affair = service.findAffairs(search);
//            if (affair != null) {
//                return new ResponseEntity<List<Affairs>>(affair, new HttpHeaders(), HttpStatus.OK);
//            } else {
//                return new ResponseEntity<List<Affairs>>(null, new HttpHeaders(), HttpStatus.NOT_FOUND);
//            }
//        }catch(Exception e){
//            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Value Not Found", e);
//        }
//        
//    }
    
}

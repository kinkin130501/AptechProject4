/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers;

import com.example.project.entities.Projectgroups;
import com.example.project.services.PGroupService;
import java.util.ArrayList;
import java.util.List;
import javax.validation.Valid;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

/**
 *
 * @author vuchu
 */
@RestController
public class PGroupController {
    
    @Autowired
    PGroupService service;   
    
    public PGroupController(PGroupService service){
        this.service = service;
    }
    @GetMapping(value = "/pgroups")
    public ResponseEntity<List<Projectgroups>> getAll() {
        try {
            List<Projectgroups> list = new ArrayList<>();
            list = service.findAll();
            return new ResponseEntity<List<Projectgroups>>(list, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Projectgroup Not Found", e);
        }

    }
    
    @PostMapping(value = "/pgroups")
    public ResponseEntity<Projectgroups> createOrUpdate(@Valid @RequestBody Projectgroups pg) {
        try {
            Projectgroups updated = service.createOrUpdatePgroups(pg);
            return new ResponseEntity<Projectgroups>(updated, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.BAD_REQUEST, "Create Failed", e);
        }

    }
    
}

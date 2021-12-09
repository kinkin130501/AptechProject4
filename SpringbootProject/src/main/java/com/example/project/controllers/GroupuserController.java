/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.controllers;

import com.example.project.entities.Groupuser;
import com.example.project.services.GroupuserService;
import java.util.ArrayList;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

/**
 *
 * @author vuchu
 */
@RestController
public class GroupuserController {
    
    @Autowired
    GroupuserService service;   
    
    public GroupuserController(GroupuserService service){
        this.service = service;
    }
    @GetMapping(value = "/groupusers")
    public ResponseEntity<List<Groupuser>> getAll() {
        try {
            List<Groupuser> list = new ArrayList<>();
            list = service.findAll();
            return new ResponseEntity<List<Groupuser>>(list, new HttpHeaders(), HttpStatus.OK);
        } catch (Exception e) {
            throw new ResponseStatusException(HttpStatus.NOT_FOUND, "Employees Not Found", e);
        }

    }
    
}

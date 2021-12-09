/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services;

import com.example.project.entities.Groupuser;
import com.example.project.repositories.GroupuserRepository;
import java.util.List;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 *
 * @author vuchu
 */
@Service
public class GroupuserService {
     @Autowired
    GroupuserRepository repository;
    
    //list
    public List<Groupuser> findAll() {
        List<Groupuser> list = repository.findAll();
        return list;
    }
}

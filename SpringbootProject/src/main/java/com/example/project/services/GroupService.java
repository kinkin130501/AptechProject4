/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services;

import com.example.project.entities.Groups;
import com.example.project.repositories.GroupRepository;
import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 *
 * @author vuman
 */
@Service
public class GroupService {
 @Autowired
    GroupRepository repository;
    
//    public KPIService(KPIRepository repository){
//        this.repository = repository;
//    }
    
    //list
    public List<Groups> findAllGroup(){
        return repository.findAll();
    }
    
    //create - update
    public Groups createAndupdateGroup(Groups group){
        if (group.getGroupid()!= null) {
            Optional<Groups> existgroup = repository.findById(group.getGroupid());

            if (existgroup.isPresent()) {
                Groups gr = existgroup.get();
                gr.setGroupname(group.getGroupname());
//                gr.setProjectid(group.getProjectid());
                //gr.setUserid(group.getUserid());
                gr = repository.save(gr);
                return gr;
            } else {
                group = repository.save(group);

                return group;
            }
        } else {
            group = repository.save(group);
            return group;
        }
    }
    
    //delete
        public void deleteGroupByID(int gid) {
        Optional<Groups> ks = repository.findById(gid);

        if (ks.isPresent()) {
            repository.deleteById(gid);
        }
    }
}

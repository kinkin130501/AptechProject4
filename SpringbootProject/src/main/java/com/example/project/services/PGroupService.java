/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services;

import com.example.project.entities.Projectgroups;
import com.example.project.repositories.PGroupRepository;
import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 *
 * @author vuchu
 */
@Service
public class PGroupService {
    @Autowired
    PGroupRepository repository;

    public List<Projectgroups> findAll() {
        return repository.findAll();
    }
    
    public Projectgroups createOrUpdatePgroups(Projectgroups pgroup) {

        if (pgroup.getProjectid()!= null) {
            Optional<Projectgroups> existpro = repository.findById(pgroup.getProjectid());

            if (existpro.isPresent()) {
                Projectgroups newgroup = existpro.get();
                newgroup.setGroupid(pgroup.getGroupid());
                newgroup = repository.save(newgroup);
                return newgroup;
            } else {
                pgroup = repository.save(pgroup);

                return pgroup;
            }
        } else {
            pgroup = repository.save(pgroup);
            return pgroup;
        }
    }
    
//    public void deleteProjectsById(int projectid) {
//        Optional<Projectgroup> aff = repository.findById(projectid);
//
//        if (aff.isPresent()) {
//            repository.deleteById(projectid);
//        }
//    }
}

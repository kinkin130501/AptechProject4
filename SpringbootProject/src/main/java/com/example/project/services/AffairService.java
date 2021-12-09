/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services;

import com.example.project.entities.Affairs;
import com.example.project.repositories.AffairRepository;
import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 *
 * @author vuchu
 */
@Service
public class AffairService{
    @Autowired
    AffairRepository repository;

    public List<Affairs> findAll() {
        List<Affairs> list = repository.findAll();
        return list;
    }
    
    public Affairs createOrUpdateAffairs(Affairs affair) {

        if (affair.getAffairid()!= null) {
            
            Optional<Affairs> existaf = repository.findById(affair.getAffairid());

            if (existaf.isPresent()) {
                Affairs aff = existaf.get();
                aff.setAffairname(affair.getAffairname());
                aff.setAffairtag(affair.getAffairtag());
                aff.setStarttimeplan(affair.getStarttimeplan());
                aff.setEndtimeplan(affair.getEndtimeplan());
                aff.setStarttimeactual(affair.getStarttimeactual());
                aff.setEndtimeactual(affair.getEndtimeactual());
                aff.setStatus(affair.getStatus());
                aff.setUserid(affair.getUserid());
                aff.setNoteleader(affair.getNoteleader());
                aff.setNotemember(affair.getNotemember());                
                aff.setProjectid(affair.getProjectid());
                aff.setTypeofaffair(affair.getTypeofaffair());
                aff = repository.save(aff);
                return aff;
            } else {
                affair = repository.save(affair);

                return affair;
            }
        } else {
            affair = repository.save(affair);
            return affair;
        }
    }
    
    public void deleteAffairsById(int affairid) {
        Optional<Affairs> aff = repository.findById(affairid);

        if (aff.isPresent()) {
            repository.deleteById(affairid);
        }
    }
    
}

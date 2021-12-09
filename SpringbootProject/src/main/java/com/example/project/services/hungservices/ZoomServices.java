/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services.hungservices;

import com.example.project.entities.Zoom;
import com.example.project.repositories.hungrepo.ZoomRepository;
import org.springframework.stereotype.Service;
import com.example.project.services.hungservices.*;
import java.util.List;
/**
 *
 * @author Admin
 */
@Service
public class ZoomServices implements ZoomInterface{
    //init repo
    private ZoomRepository repo;
    List<Zoom> listAll;
    //init constructor
    public ZoomServices(ZoomRepository repo,List<Zoom> listAll)
    {
        this.repo = repo;
        this.listAll = listAll;
    }
    @Override
    public List<Zoom> findAllZoomById(int id) {
        return repo.findAllZoomById(id);
    }

    @Override
    public Zoom findOneZoom(int id) {
        return repo.findZoomById(id);
    }

    @Override
    public Zoom UpdateZoom(Zoom z) {
        Zoom result = new Zoom();
        try {
            result = repo.save(z);
        } catch (Exception e) {
            System.out.println("Error :"+ e.getMessage());
        }
        return result;
    }

    @Override
    public boolean DeleteZoom(Zoom z) {
        boolean flag = true;
        try {
            repo.deleteById(z.getZoomid());
        } catch (Exception e) {
            System.out.println("Error :"+ e.getMessage());
            flag = false;
        }
        return flag;
    }

//    @Override
//    public Zoom CreateZoom(Zoom z) {
//        try {
//            repo.save(z);
//        } catch (Exception e) {
//            
//        }
//    }

    @Override
    public List<Zoom> findAllZoomByIdOther(int id) {
        return repo.findAllZoomByIdOther(id);
    }

    @Override
    public List<Zoom> findAllTeamZoom() {
        return repo.findAll();
    }
    
}

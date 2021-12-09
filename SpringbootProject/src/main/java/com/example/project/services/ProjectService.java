/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services;

import com.example.project.entities.Projects;
import com.example.project.repositories.ProjectRepository;
import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 *
 * @author vuchu
 */
@Service
public class ProjectService{
    @Autowired
    ProjectRepository repository;

    public List<Projects> findAll() {
        return (List<Projects>) repository.findAll();
    }
    public Projects createOrUpdateProjects(Projects project) {

        if (project.getProjectid()!= null) {
            Optional<Projects> existpro = repository.findById(project.getProjectid());

            if (existpro.isPresent()) {
                Projects newPro = existpro.get();
                newPro.setProjectname(project.getProjectname());
                newPro.setLeaderid(project.getLeaderid());
                newPro.setStartplan(project.getStartplan());
                newPro.setStartactual(project.getStartactual());
                newPro.setEndplan(project.getEndplan());
                newPro.setEndactual(project.getEndactual());
                newPro.setNote(project.getNote());
                newPro.setStatus(project.getStatus());
                newPro.setDocid(project.getDocid());
                newPro.setProjectcode(project.getProjectcode());
                newPro.setRequire(project.getRequire());
                newPro = repository.save(newPro);
                return newPro;
            } else {
                project = repository.save(project);

                return project;
            }
        } else {
            project = repository.save(project);
            return project;
        }
    }
    
    public void deleteProjectsById(int projectid) {
        Optional<Projects> aff = repository.findById(projectid);

        if (aff.isPresent()) {
            repository.deleteById(projectid);
        }
    }
    
   public Optional<Projects> findById(int pid){
        return repository.findById(pid);
    }
}

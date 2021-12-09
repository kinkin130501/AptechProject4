/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services;

import com.example.project.entities.Documents;
import com.example.project.repositories.DocumentRepository;
import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 *
 * @author vuchu
 */
@Service
public class DocumentService{
    @Autowired
    DocumentRepository repository;

    public List<Documents> findAll() {
        return repository.findAll();
    }
    
    public Documents createOrUpdateDocuments(Documents document) {

        if (document.getDocid() != null) {
            Optional<Documents> existdoc = repository.findById(document.getDocid());
            if (existdoc.isPresent()) {
                Documents doc = existdoc.get();
                doc.setTitle(document.getTitle());
                doc.setAuthorname(document.getAuthorname());
                doc.setAuthorrole(document.getAuthorrole());
                doc.setFiles(document.getFiles());
                doc.setNote(document.getNote());
                doc = repository.save(doc);
                return doc;
            } else {
                document = repository.save(document);

                return document;
            }
        } else {
            document = repository.save(document);
            return document;
        }
    }
    
    public void deleteDocumentsById(int docId) {
        Optional<Documents> acc = repository.findById(docId);

        if (acc.isPresent()) {
            repository.deleteById(docId);
        }
    }
}
/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.services;

import com.example.project.entities.Request;
import com.example.project.repositories.RequestRepository;
import java.util.List;
import java.util.Optional;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 *
 * @author vuman
 */
@Service
public class RequestService {
    @Autowired
    RequestRepository repository;

    public List<Request> findAll() {
        List<Request> list = repository.findAll();
        return list;
    }
    public Request createOrUpdateRequest(Request request) {

        if (request.getRequestid()!= null) {
            Optional<Request> existrq = repository.findById(request.getRequestid());
            if (existrq.isPresent()) {
                Request rq = existrq.get();
                rq.setRequestname(request.getRequestname());
                rq.setContent(request.getContent());
                rq.setUserid(request.getUserid());
                rq.setReceiverid(request.getReceiverid());
                rq.setSentdate(request.getSentdate());
                rq.setMoretime(request.getMoretime());
                rq.setStatus(request.getStatus());
                rq.setResponecontent(request.getResponecontent());
                rq.setReply(request.getReply());
                rq.setTaskid(request.getTaskid());
                rq.setRequestmoney(request.getRequestmoney());
                rq.setTotaltime(request.getTotaltime());
                rq = repository.save(rq);
                return rq;
            } else {
                request = repository.save(request);

                return request;
            }
        } else {
            request = repository.save(request);
            return request;
        }
    }
    
    public void deleteById(int requestID) {
        Optional<Request> rq = repository.findById(requestID);

        if (rq.isPresent()) {
            repository.deleteById(requestID);
        }
    }
    
    public Optional<Request> findById(int rid){
        return repository.findById(rid);
    }
    
    
}
   

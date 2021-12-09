/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.entities;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author vuman
 */
@Entity
@Table(name = "Otime")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Otime.findAll", query = "SELECT o FROM Otime o"),
    @NamedQuery(name = "Otime.findByOtid", query = "SELECT o FROM Otime o WHERE o.otid = :otid"),
    @NamedQuery(name = "Otime.findByReason", query = "SELECT o FROM Otime o WHERE o.reason = :reason"),
    @NamedQuery(name = "Otime.findByTimedelay", query = "SELECT o FROM Otime o WHERE o.timedelay = :timedelay"),
    @NamedQuery(name = "Otime.findByMessage", query = "SELECT o FROM Otime o WHERE o.message = :message"),
    @NamedQuery(name = "Otime.findByStatus", query = "SELECT o FROM Otime o WHERE o.status = :status")})
public class Otime implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "otid")
    private Integer otid;
    @Size(max = 2147483647)
    @Column(name = "reason")
    private String reason;
    @Basic(optional = false)
    @NotNull
    @Column(name = "timedelay")
    @Temporal(TemporalType.TIMESTAMP)
    private Date timedelay;
    @Size(max = 2147483647)
    @Column(name = "message")
    private String message;
    @Basic(optional = false)
    @NotNull
    @Column(name = "status")
    private boolean status;

    public Otime() {
    }

    public Otime(Integer otid) {
        this.otid = otid;
    }

    public Otime(Integer otid, Date timedelay, boolean status) {
        this.otid = otid;
        this.timedelay = timedelay;
        this.status = status;
    }

    public Integer getOtid() {
        return otid;
    }

    public void setOtid(Integer otid) {
        this.otid = otid;
    }

    public String getReason() {
        return reason;
    }

    public void setReason(String reason) {
        this.reason = reason;
    }

    public Date getTimedelay() {
        return timedelay;
    }

    public void setTimedelay(Date timedelay) {
        this.timedelay = timedelay;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public boolean getStatus() {
        return status;
    }

    public void setStatus(boolean status) {
        this.status = status;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (otid != null ? otid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Otime)) {
            return false;
        }
        Otime other = (Otime) object;
        if ((this.otid == null && other.otid != null) || (this.otid != null && !this.otid.equals(other.otid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.Otime[ otid=" + otid + " ]";
    }
    
}

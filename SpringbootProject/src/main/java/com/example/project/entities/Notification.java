/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.entities;

import java.io.Serializable;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.Table;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Admin
 */
@Entity
@Table(name = "Notification")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Notification.findAll", query = "SELECT n FROM Notification n"),
    @NamedQuery(name = "Notification.findByNotiid", query = "SELECT n FROM Notification n WHERE n.notiid = :notiid"),
    @NamedQuery(name = "Notification.findByNotitype", query = "SELECT n FROM Notification n WHERE n.notitype = :notitype"),
    @NamedQuery(name = "Notification.findByNotiuserid", query = "SELECT n FROM Notification n WHERE n.notiuserid = :notiuserid"),
    @NamedQuery(name = "Notification.findByNotiread", query = "SELECT n FROM Notification n WHERE n.notiread = :notiread"),
    @NamedQuery(name = "Notification.findByNoticreate", query = "SELECT n FROM Notification n WHERE n.noticreate = :noticreate"),
    @NamedQuery(name = "Notification.findByNotiupdate", query = "SELECT n FROM Notification n WHERE n.notiupdate = :notiupdate"),
    @NamedQuery(name = "Notification.findByNotifromid", query = "SELECT n FROM Notification n WHERE n.notifromid = :notifromid")})
public class Notification implements Serializable {

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "notiid")
    private Integer notiid;
    @Size(max = 50)
    @Column(name = "notitype")
    private String notitype;
    @Column(name = "notiuserid")
    private Integer notiuserid;
    @Column(name = "notiread")
    private Integer notiread;
    @Size(max = 50)
    @Column(name = "noticreate")
    private String noticreate;
    @Size(max = 50)
    @Column(name = "notiupdate")
    private String notiupdate;
    @Column(name = "notifromid")
    private Integer notifromid;

    public Notification() {
    }

    public Notification(Integer notiid) {
        this.notiid = notiid;
    }

    public Integer getNotiid() {
        return notiid;
    }

    public void setNotiid(Integer notiid) {
        this.notiid = notiid;
    }

    public String getNotitype() {
        return notitype;
    }

    public void setNotitype(String notitype) {
        this.notitype = notitype;
    }

    public Integer getNotiuserid() {
        return notiuserid;
    }

    public void setNotiuserid(Integer notiuserid) {
        this.notiuserid = notiuserid;
    }

    public Integer getNotiread() {
        return notiread;
    }

    public void setNotiread(Integer notiread) {
        this.notiread = notiread;
    }

    public String getNoticreate() {
        return noticreate;
    }

    public void setNoticreate(String noticreate) {
        this.noticreate = noticreate;
    }

    public String getNotiupdate() {
        return notiupdate;
    }

    public void setNotiupdate(String notiupdate) {
        this.notiupdate = notiupdate;
    }

    public Integer getNotifromid() {
        return notifromid;
    }

    public void setNotifromid(Integer notifromid) {
        this.notifromid = notifromid;
    }

    @Override
    public int hashCode() {
        int hash = 0;
        hash += (notiid != null ? notiid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Notification)) {
            return false;
        }
        Notification other = (Notification) object;
        if ((this.notiid == null && other.notiid != null) || (this.notiid != null && !this.notiid.equals(other.notiid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.Notification[ notiid=" + notiid + " ]";
    }
    
}

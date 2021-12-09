/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.example.project.entities;

import java.io.Serializable;
import java.util.List;
import javax.persistence.Basic;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.NamedQueries;
import javax.persistence.NamedQuery;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.Size;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author vuchu
 */
@Entity
@Table(name = "Documents")
@XmlRootElement
@NamedQueries({
    @NamedQuery(name = "Documents.findAll", query = "SELECT d FROM Documents d"),
    @NamedQuery(name = "Documents.findByDocid", query = "SELECT d FROM Documents d WHERE d.docid = :docid"),
    @NamedQuery(name = "Documents.findByTitle", query = "SELECT d FROM Documents d WHERE d.title = :title"),
    @NamedQuery(name = "Documents.findByAuthorrole", query = "SELECT d FROM Documents d WHERE d.authorrole = :authorrole"),
    @NamedQuery(name = "Documents.findByAuthorname", query = "SELECT d FROM Documents d WHERE d.authorname = :authorname"),
    @NamedQuery(name = "Documents.findByFiles", query = "SELECT d FROM Documents d WHERE d.files = :files"),
    @NamedQuery(name = "Documents.findByNote", query = "SELECT d FROM Documents d WHERE d.note = :note")})
public class Documents implements Serializable {

    @Size(max = 2147483647)
    @Column(name = "title")
    private String title;
    @Size(max = 2147483647)
    @Column(name = "authorname")
    private String authorname;
    @Size(max = 2147483647)
    @Column(name = "files")
    private String files;
    @Size(max = 2147483647)
    @Column(name = "note")
    private String note;

    private static final long serialVersionUID = 1L;
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Basic(optional = false)
    @Column(name = "docid")
    private Integer docid;
    @Column(name = "authorrole")
    private Integer authorrole;

    public Documents() {
    }

    public Documents(Integer docid) {
        this.docid = docid;
    }

    public Integer getDocid() {
        return docid;
    }

    public void setDocid(Integer docid) {
        this.docid = docid;
    }


    public Integer getAuthorrole() {
        return authorrole;
    }

    public void setAuthorrole(Integer authorrole) {
        this.authorrole = authorrole;
    }



    @Override
    public int hashCode() {
        int hash = 0;
        hash += (docid != null ? docid.hashCode() : 0);
        return hash;
    }

    @Override
    public boolean equals(Object object) {
        // TODO: Warning - this method won't work in the case the id fields are not set
        if (!(object instanceof Documents)) {
            return false;
        }
        Documents other = (Documents) object;
        if ((this.docid == null && other.docid != null) || (this.docid != null && !this.docid.equals(other.docid))) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "com.example.project.entities.Documents[ docid=" + docid + " ]";
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAuthorname() {
        return authorname;
    }

    public void setAuthorname(String authorname) {
        this.authorname = authorname;
    }

    public String getFiles() {
        return files;
    }

    public void setFiles(String files) {
        this.files = files;
    }

    public String getNote() {
        return note;
    }

    public void setNote(String note) {
        this.note = note;
    }

    
}

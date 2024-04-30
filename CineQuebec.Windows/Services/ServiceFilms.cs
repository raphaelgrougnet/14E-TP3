﻿using CineQuebec.Windows.DAL.Repositories;
using CineQuebec.Windows.Domain;
using CineQuebec.Windows.Services.Interfaces;
using MongoDB.Bson;

namespace CineQuebec.Windows.Services;

public class ServiceFilms : IServiceFilms
{
    private RepositoryFilms _repositoryFilms;
    
    public ServiceFilms(RepositoryFilms repositoryFilms)
    {
        _repositoryFilms = repositoryFilms;
    }
    
    public List<Film> GetFilms()
    {
        return _repositoryFilms.LoadFilms();
    }

    public Film AddFilm(Film pFilm)
    {
        return _repositoryFilms.AddFilm(pFilm);
    }

    public List<Film> LoadFilmsAffiche()
    {
        return _repositoryFilms.LoadFilmsAffiche();
    }
}
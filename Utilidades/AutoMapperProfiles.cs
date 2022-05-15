using System.Security.AccessControl;
using AutoMapper;
using Back_end.DTOs;
using Back_end.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Back_end.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Genero,GeneroDTO>().ReverseMap(); 
            CreateMap<GeneroCreacionDTO,Genero>();
        }
        
    }
}
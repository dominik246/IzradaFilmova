using AutoMapper;

using IzradaFilmova.Database.Models;
using IzradaFilmova.Shared.APITemplate.DTOs.ActorController;

namespace IzradaFilmova.Features.Actor
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ActorEntity, ActorDTO>();

            CreateMap<MovieGenreRelationEntity, GenreDTO>().ForMember(p => p.GenreName, dest => dest.MapFrom(src => src.Genre != null ? src.Genre.GenreName : null));
            CreateMap<ActorMovieRelationEntity, ActorDTO>().ForMember(p => p.FirstName, dest => dest.MapFrom(src => src.Actor != null ? src.Actor.FirstName : null))
                                                           .ForMember(p => p.LastName, dest => dest.MapFrom(src => src.Actor != null ? src.Actor.LastName : null));

            CreateMap<MovieEntity, MovieDTO>().ForMember(p => p.Genres, dest => dest.MapFrom(src => src.MovieGenreRelations))
                                              .ForMember(p => p.Actors, dest => dest.MapFrom(src => src.ActorMovieRelations));

            CreateMap<DirectorEntity, DirectorDTO>();
            CreateMap<UpdateActorProfileDTO, ActorEntity>();
        }
    }
}

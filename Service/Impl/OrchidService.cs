using AutoMapper;
using BussinessObjects;
using BussinessObjects.Enums;
using Repositories;
using Service.Model.Request;
using Service.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Impl
{
    public class OrchidService : IOrchidService
    {
        private IOrchidRepository _orchidRepository;
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public OrchidService(IOrchidRepository orchidRepository, IUserRepository userRepository, IMapper mapper)
        {
            _orchidRepository = orchidRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public OrchidRequestDto? AddOrchid(OrchidRequestDto orchidRequestDto)
        {
            if (orchidRequestDto != null)
            {
                Orchid orchid = _mapper.Map<Orchid>(orchidRequestDto);
                orchid.DepositedStatus = DepositedStatus.Available;
                //add to db
                _orchidRepository.AddOrchid(orchid);
                orchidRequestDto = _mapper.Map<OrchidRequestDto>(orchid);
            }
            return orchidRequestDto;
        }

        public IEnumerable<OrchidResponseDto> GetAll()
        {
            List<OrchidResponseDto> orchidResponseDtos =
                _mapper.Map<List<OrchidResponseDto>>(_orchidRepository.GetAll());
            return orchidResponseDtos;
        }

        public OrchidResponseDto? GetOrchidById(Guid id)
        {
            return _mapper.Map<OrchidResponseDto>(_orchidRepository.GetOrchidById(id));
        }

        public OrchidResponseDto? GetOrchidByName(string name)
        {
            return _mapper.Map<OrchidResponseDto>(_orchidRepository.GetOrchidByName(name));
        }

        public void RemoveOrchid(Guid id)
        {
            _orchidRepository.RemoveOrchid(id);
        }

        public EditOrchidDto? UpdateOrchid(EditOrchidDto orchidDto)
        {
            Orchid updatedOrchid = null;
            if (orchidDto != null)
            {
                Orchid orchid = _orchidRepository.GetOrchidByName(orchidDto.Name);
                if (orchid == null)
                {
                    return null;
                }
                else { 
                    //if orchid exist
                    orchid.Name = orchidDto.Name;
                    orchid.ImageUrl = orchidDto.ImageUrl;
                    orchid.DepositedStatus = orchidDto.DepositedStatus;
                    orchid.Description = orchidDto.Description;
                    //update to db
                     updatedOrchid = _orchidRepository.UpdateOrchid(orchid);
                    //return updated orchid
                    return _mapper.Map<EditOrchidDto>(updatedOrchid);
                }
            }
            return null;
        }
    }
}

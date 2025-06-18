using AutoMapper;
using Krispy.AccessData.Data.Repository.IRepository;
using Krispy.Models.Dtos.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XSystem.Security.Cryptography;

namespace Krispy.Api.Controllers.Access
{
    public class UserController : Controller
    {
        private readonly IContent _content;
        private readonly IMapper _mapper;
        private string _keyApi;

        public UserController(IContent content,IMapper mapper, IConfiguration config)
        {
            _content = content;
            _mapper = mapper;
            _keyApi = config.GetValue<string>("ApiSetting:keyApi");
        }

       
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("PostLogin")]
        public IActionResult Login([FromBody] AccesoDto item) {

            var codigoHash = ObtenerMD5(item.ContrasenaHash);
            var usr = _content.Usuario.GetFirstOrDefault(
                u => u.NombreUsuario.ToLower() == item.NombreUsuario.ToLower()
                && u.ContrasenaHash == codigoHash);

            if (usr == null)
                return NotFound();

            var handlerToken = new JwtSecurityTokenHandler();
            var coding = Encoding.UTF8.GetBytes(_keyApi);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
            new Claim(ClaimTypes.Name, usr.NombreUsuario.ToString()),
            new Claim(ClaimTypes.NameIdentifier, usr.UsuarioId.ToString())
        }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new(new SymmetricSecurityKey(coding), SecurityAlgorithms.HmacSha256)
            };
            var token = handlerToken.CreateToken(tokenDescriptor);

            var userRequest = new TokenDto()
            {
                Token = handlerToken.WriteToken(token),
                Usuario = _mapper.Map<UsuarioDto>(usr)
            };

            return Ok(userRequest);


        }

        private string ObtenerMD5(string contrasenaHash)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(contrasenaHash);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
                resp += data[i].ToString("x2").ToLower();
            return resp;

        }
    }
}

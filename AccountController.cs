
[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly AuthService _authService;

    public AccountController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid) return BadRequest("Invalid input");

        var user = await _authService.AuthenticateAsync(request.Username, request.Password);
        if (user == null) return Unauthorized();

        return Ok(new { Token = "mock-jwt-token", Role = user.Role });
    }
}

public class LoginRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}

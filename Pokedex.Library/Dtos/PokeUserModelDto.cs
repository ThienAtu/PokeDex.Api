﻿namespace Pokedex.Library.Dtos;

public class PokeUserModelDto
{
  public string UserName { get; set; } = string.Empty;

  public string Password { get; set; } = string.Empty;

  public int RoleId { get; set; }

  public int Status { get; set; }
}

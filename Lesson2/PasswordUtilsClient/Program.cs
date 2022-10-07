// See https://aka.ms/new-console-template for more information
using CardStorageService.Utils;

var result = PasswordUtils.CreatePasswordHash("1587panda");
    Console.WriteLine(result.passwordSalt);
    Console.WriteLine(result.passwordHash);
    Console.ReadKey(true);
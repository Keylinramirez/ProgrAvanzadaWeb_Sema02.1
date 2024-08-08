using APW.DataSource;
using APW.Models;

namespace APW.Indicators;

public interface IPlayerService
{
    IEnumerable<Player> GetAllPlayersByTeam(string teamName);
    IEnumerable<Player> GetOldestPlayerByTeam();
    IEnumerable<Player> GetRetiredtPlayer();
    Player GetSinglePlayerByTeam(string teamName);
    Player GetYoungestPlayer();
    PlayerSource All { get; }
}

public class PlayerService : IPlayerService
{
    private readonly PlayerSource _playerSource;

    public PlayerSource All {  get { return _playerSource; } }

    public PlayerService()
    {
        _playerSource = new PlayerSource();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="teamName"></param>
    /// <returns></returns>

    public Player GetSinglePlayerByTeam(string teamName)
    {
        var players = _playerSource.ParseAndReturnData();
        return players.FirstOrDefault(p => p.Club == teamName) ?? throw new InvalidOperationException("Player not found");

        /*  1 Punto.
         
            Título: 
            Como desarrollador, quiero agregar una consulta LINQ para devolver 
            un único jugador de un equipo y corregir el valor de retorno.

            Descripción:
            Como parte del desarrollo del sistema de gestión de equipos deportivos, 
            necesitamos implementar una funcionalidad que permita recuperar
            un único jugador de un equipo mediante una consulta LINQ. Además, es 
            crucial corregir el valor de retorno para garantizar que sea el esperado.

            Criterios de Aceptación:
            1. La consulta LINQ devuelve correctamente un único jugador de un equipo.
            2. El valor de retorno de la consulta LINQ es el esperado.
            3. El profesor utilizara una prueba unitaria para verificar la funcionalidad.
            4. Si La prueba unitaria pasa exitosamente después de la implementación de la funcionalidad, tiene los puntos.
            5. Se ha realizado una revisión del código para garantizar la calidad y coherencia del mismo.
            6. La funcionalidad implementada se ha integrado correctamente con el API.
        */
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="teamName"></param>
    /// <returns></returns>
    public IEnumerable<Player> GetAllPlayersByTeam(string teamName)
    {
        var players = _playerSource.ParseAndReturnData();

        // Devuelve todos los jugadores de un equipo
        return players.Where(p => p.Club == teamName);

        /*  1 Punto.

            Título: 
            Como desarrollador, quiero agregar una consulta LINQ para devolver 
            TODOs los jugadores de solo un equipo y corregir el valor de retorno.

            Descripción:
            Como parte del desarrollo del sistema de gestión de equipos deportivos, 
            necesitamos implementar una funcionalidad que permita recuperar
            TODOs los jugadores de solo un equipo mediante una consulta LINQ. Además, es 
            crucial corregir el valor de retorno para garantizar que sea el esperado.

            Criterios de Aceptación:
            1. La consulta LINQ devuelve correctamente TODOs los jugadores de solo un equipo.
            2. El valor de retorno de la consulta LINQ es el esperado.
            3. El profesor utilizara una prueba unitaria para verificar la funcionalidad.
            4. Si La prueba unitaria pasa exitosamente después de la implementación de la funcionalidad, tiene los puntos.
            5. Se ha realizado una revisión del código para garantizar la calidad y coherencia del mismo.
            6. La funcionalidad implementada se ha integrado correctamente con el API.
        */
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="teamName"></param>
    /// <returns></returns>
    /// 

    public IEnumerable<Player> GetOldestPlayerByTeam()
    {
        var players = _playerSource.ParseAndReturnData();

        return players.GroupBy(p => p.Club)
           .Select(g => g.OrderBy(p => p.DateOfBirth).FirstOrDefault() ?? new Player());

        /*  1 Punto.

            Título: 
            Como desarrollador, quiero agregar una consulta LINQ para devolver 
            top 1 de los jugadores mas longevos por equipo y corregir el valor de retorno.

            Descripción:
            Como parte del desarrollo del sistema de gestión de equipos deportivos, 
            necesitamos implementar una funcionalidad que permita recuperar
            top 1 de los jugadores mas longevos por equipo mediante una consulta LINQ. Además, es 
            crucial corregir el valor de retorno para garantizar que sea el esperado y tomar en 
            cuenta la fecha de nacimiento de los jugadores.

            Criterios de Aceptación:
            1. La consulta LINQ devuelve correctamente top 1 de los jugadores mas longevos por equipo.
            2. El valor de retorno de la consulta LINQ es el esperado.
            3. El profesor utilizara una prueba unitaria para verificar la funcionalidad.
            4. Si La prueba unitaria pasa exitosamente después de la implementación de la funcionalidad, tiene los puntos.
            5. Se ha realizado una revisión del código para garantizar la calidad y coherencia del mismo.
            6. La funcionalidad implementada se ha integrado correctamente con el API.
        */
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="teamName"></param>
    /// <returns></returns>
    public Player GetYoungestPlayer()
    {
        var players = _playerSource.ParseAndReturnData();

        // Devuelve un valor predeterminado si la lista está vacía
        return players.OrderBy(p => p.DateOfBirth).LastOrDefault() ?? new Player(); // O crea un nuevo Player

        /*  1 Punto.

            Título: 
            Como desarrollador, quiero agregar una consulta LINQ para devolver 
            el jugador mas joven de toda la lista y corregir el valor de retorno.

            Descripción:
            Como parte del desarrollo del sistema de gestión de equipos deportivos, 
            necesitamos implementar una funcionalidad que permita recuperar
            el jugador mas joven de toda la lista mediante una consulta LINQ. Además, es 
            crucial corregir el valor de retorno para garantizar que sea el esperado y 
            tomar en cuenta la fecha de nacimiento de los jugadores.

            Criterios de Aceptación:
            1. La consulta LINQ devuelve correctamente el jugador mas joven de toda la lista.
            2. El valor de retorno de la consulta LINQ es el esperado.
            3. El profesor utilizara una prueba unitaria para verificar la funcionalidad.
            4. Si La prueba unitaria pasa exitosamente después de la implementación de la funcionalidad, tiene los puntos.
            5. Se ha realizado una revisión del código para garantizar la calidad y coherencia del mismo.
            6. La funcionalidad implementada se ha integrado correctamente con el API.
        */
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="teamName"></param>
    /// <returns></returns>
    public IEnumerable<Player> GetRetiredtPlayer()
    {
        var players = _playerSource.ParseAndReturnData();

        // Devuelve la lista de jugadores retirados sin repetidos
        return players.Where(p => p.IsRetired).Distinct();

        /*  1 Punto.

            Título: 
            Como desarrollador, quiero agregar una consulta LINQ para devolver 
            la lista DISTINTA (sin repetidos) de los jugadores retirados 
            y corregir el valor de retorno.

            Descripción:
            Como parte del desarrollo del sistema de gestión de equipos deportivos, 
            necesitamos implementar una funcionalidad que permita recuperar
            la lista DISTINTA (sin repetidos) de los jugadores retirados
            mediante una consulta LINQ. Además, es crucial corregir el valor de 
            retorno para garantizar que sea el esperado.

            Criterios de Aceptación:
            1. La consulta LINQ devuelve correctamente la lista DISTINTA (sin repetidos) de los jugadores retirados.
            2. El valor de retorno de la consulta LINQ es el esperado.
            3. El profesor utilizara una prueba unitaria para verificar la funcionalidad.
            4. Si La prueba unitaria pasa exitosamente después de la implementación de la funcionalidad, tiene los puntos.
            5. Se ha realizado una revisión del código para garantizar la calidad y coherencia del mismo.
            6. La funcionalidad implementada se ha integrado correctamente con el API.
        */
    }
}
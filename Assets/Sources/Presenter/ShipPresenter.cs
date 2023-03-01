using UnityEngine;

public class ShipPresenter : Presenter
{
    private Root _init;
    private int _healthPoints;

    public void Init(Root init)
    {
        _init = init;
        _healthPoints = 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            _healthPoints--;
            if (_healthPoints-- > 0)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                _init.DisableShip();
            }
        }
    }
}

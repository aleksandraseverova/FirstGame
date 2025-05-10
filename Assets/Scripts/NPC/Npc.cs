using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc : MonoBehaviour
{
    [SerializeField] protected int health = 100;//Здоровье
    [SerializeField] protected float attackDistance = 3;//
    //[SerializeField] 
    protected int damage = 10; //Изменение здоровья
    [SerializeField] protected float cooldown = 1;
    protected GameObject player;
    protected Animator anim;
    protected Rigidbody rb;
    protected float distance;
    protected float timer;
     bool dead = false;
  

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject; 
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        GetComponent<Collider>().enabled = true;
    }

    // Update is called once per frame
    private void Update()
    {
        // //Создаём переменную, которая будет хранить минимальную дистанцию
        // //Mathf.Infinity - положительная бесконечность
        //float closestDistance = Mathf.Infinity;
        // //перебираем весь список игроков
        // foreach (GameObject closestPlayer in players)
        // {
          //высчитываем расстояние до игрока
          //если дистанция до игрока меньше, чем дистанция до предыдущего проверенного игрока, то...
            // if (checkDistance < closestDistance)
            // {
                //если ближайший игрок жив
                // if (closestPlayer.GetComponent<PlayerController>().dead == false)
                // {
                   //в переменную player помещаем этого игрока
                    //player = closestPlayer;
                    //изменяем значение переменной closestDistance на расстояние до этого игрока
                    //closestDistance = checkDistance;
                //}
            // }
        // }
        //проверяем есть ли в переменной player игрок
        //это нужно для того, чтобы не возникало ошибок
        if (player != null)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);

            if (!dead)
            {
                Attack();
            }
        }
    }

    public virtual void Move()
    {

    }

    public virtual void Attack()
    {

    }

    private void FixedUpdate()
    {
        if (!dead && player != null)
        {
            Move();
        }
    }

        public void ChangeHealth(int count)
    {
        //отнимаем здоровье
        health -= count;
        // float fillPercent = health / 100f;
        // healthBar.fillAmount = fillPercent;
        //если здоровье меньше, либо равно нулю, то..
        if (health <= 0)
        {
            //меняем значение булевой переменной(перестают работать методы Attack и Move
            dead = true;
            //отключаем коллайдер врага
            GetComponent<Collider>().enabled = false;
            anim.enabled = true;
            //включаем анимацию смерти
            anim.SetBool("Die", true);
        }

    }
}

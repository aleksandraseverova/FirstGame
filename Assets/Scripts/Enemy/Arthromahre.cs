using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arthromahre : Enemy
{
    [SerializeField] float speed = 3; //Скорость 
    [SerializeField] float detectionDistance = 10; //Радиус обнаружение

    float patrolTimer;

    public override void Move()
    {
        //Если расстояние между врагом и игроком меньше, чем радиус обнаружения
        // И расстояние между врагом и игроком больше, чем радиус атаки, то...
        if (distance < detectionDistance && distance > attackDistance)
        {
            //Разворачиваем врага в сторону игрока
            transform.LookAt(player.transform);
            //Включаем анимацию бега
            anim.SetBool("Fly", true);
            //Двигаем вперед      
            rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
        }

        else if (distance > detectionDistance)
        {
            // rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);
            patrolTimer += Time.deltaTime;
            anim.SetBool("Fly", true);
            if (patrolTimer > 10)
            {
                transform.Rotate(new Vector3(0, 90, 0));
                patrolTimer = 0;
            }
        }
        //иначе...
        else
        {
            //отключаем анимацию бега
            anim.SetBool("Fly", false);
        }
    }

    public override void Attack()
    {
        //Включаем таймер
        timer += Time.deltaTime;
        //Если расстояние между врагом и игроком меньше, чем расстояние для атаки и таймер больше кулдауна(время между ударами) то...
        if (distance < attackDistance && timer > cooldown)
        {
            //обнуляем таймер
            timer = 0;
            //Получаем скрипт игрока и вызываем метод изменения здоровья
            //player.GetComponent<PlayerController>().ChangeHealth(damage);
            //Активируем анимацию атаки            
            anim.SetBool("Attack", true);
        }
        //Иначе...
        else
        {
            //отключаем анимацию атаки
            anim.SetBool("Attack", false);
        }
    }
}

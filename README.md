

PhysicsProcess ir priekš fizikas.  

- 200speed/60hz = 3.33333px / s  
- 200speed/30hz = 6.66667px / s  
- 200speed * 60hz = 12000px / s  
- 200speed * 30hz = 6000px / s  


√2 = ~1.41
Velocity Player.cs papildus nereizina ar delta, jo tas ir rezināts ar delta iekša godot fizikas kodā.  

```py
def _Ready():
    health = 100
    if (health <= 0):
        print("Spēle beigusies")
    else if (health < 30):
        print("Uzmanību!")
    else:
        print("Viss kārtībā");
```
Pythonā nav {}, un ir :, nav int vai void, nav GD.


```
Punkti: 1; atslēga: False
Punkti: 2; atslēga: False
Punkti: 2; atslēga: True
Punkti: 7; atslēga: True
Atslēga ir — finišu varēs atvērt.
```


vārds: Iaj
kas ir varonis: Zaķis
ko viņš vēlas un kāpēc tas ir svarīgi: Burkānus, jo negrib nomirst.
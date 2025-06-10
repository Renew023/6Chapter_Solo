# 6Chapter_Solo
6챕터 개인과제 : 3D 방치형 RPG 구현하기

---
## 구현된 기능

***필수***
- 기본 UI 구현
- 플레이어 AI 시스템
- 아이템 및 업그레이드 시스템
- 게임 내 통화 시스템
- 아이템 및 장비창 UI 구현
- 스테이지 시스템
- ScriptableObject를 이용한 데이터 관리

***선택***
- 사운드 이펙트
- 저장 및 로드 시스템

---
## 각 기능 상세 설명

# 기본 UI 구현
- 각종 상호작용 버튼 및 능력치를 표시
- 제한된 리소스로 각 표시는 Outline과 색, Text로 설명.
![image](https://github.com/user-attachments/assets/445edadf-8029-45e7-a444-3dd90a04bfcc)


# 플레이어 AI 시스템
- 싱글톤에 저장된 몬스터들의 정보와 거리를 계산하여 가장 짧은 거리의 적을 추적.
- 일정 거리 안에 있으면 공격 패턴으로 전환.
![image](https://github.com/user-attachments/assets/47097b6d-a393-484e-a87a-619142b9c29e)



# 아이템 및 업그레이드 시스템
- 공격력, 체력, 스피드 등의 능력치 구매 가능.
- 구매한 능력치는 Player에게 적용.
![Movie_002](https://github.com/user-attachments/assets/f8d51cad-55ac-4225-8daf-798d19954846)


# 게임 내 통화 시스템
- 위 내용인 아이템 및 업그레이드 시스템에 사용하기 위한 골드.
- 몬스터를 처치 시 획득.


# 아이템 및 장비창 UI 구현
- 드랍된 아이템을 장착 기능 및 장착 해제 기능.
- 드랍 아이템 스택 기능 -> 방치형 게임 생각하며 장착 아이템 고의로 스택화.
![Movie_001](https://github.com/user-attachments/assets/7aa42c0d-a986-4690-94d5-52ebd7fdf5d4)


# 스테이지 시스템
- ScriptableObject로 Stage 구성.
- MonsterSpawner에서 List<Stage>를 통해 몬스터 생성.
![image](https://github.com/user-attachments/assets/364ac56e-cb91-47fe-8564-11277a2b4992)


# ScriptableObject를 이용한 데이터 관리
- ItemData를 InventoryItem, EquipItem, ResourceItem으로 구분하여 관리.
- ScriptableObject로 객체의 값을 지정 {Player, Enemy, Item, Stage }
![image](https://github.com/user-attachments/assets/0cccbfba-3dae-4b05-90ad-17a810b0009a)


# 사운드 이펙트
- 공격, 움직임, 죽었을 때, 버튼 눌렸을 때, 레벨업으로 구성.
- AudioManager를 싱글턴화하여 각 위치에서 실행

# 저장 및 로드 시스템
- 제네릭 메서드를 통해 어떤 값이든 저장할 수 있음.
- Setting, Inventory, Player, Stage, ShopData의 구조체를 생성해서 필요한 값만 저장.
![image](https://github.com/user-attachments/assets/abc22158-3775-4bbf-8a1a-210d8ec59713)


---
## 기술 스택

- stateMachine 패턴
    -> 플레이어 및 몬스터의 동작 제어
  
- 확장 메서드
    -> this Button을 통해 Button을 눌렀을 때 사운드 규정.
  
- 상수 키 관리
    -> Animation이나 저장할 데이터의 이름을 Hash나 string을 통해 저장하는 구조
  
- ScriptalbeObject 구조 설계
    -> ScriptableObject를 역할에 맞게 분리
  
- Update 간소화
    -> Enemy가 각기 Update를 돌리는 건 비효율적이라고 생각되어 StateMachineManager가 Update 관리  

## 트러블 슈팅
- 애니메이션 타격 오류 (25.06.10)
  - 문제 : 공격 시도하는 애니메이션이 normalizeTime이 1.0이 되지 않고 끝나버림.
  - 원인 : HasExitTime을 통해 제대로 끝나고 있는 걸로 알고 있었으나, 애니메이션이 Setting의 Transition Duration 때문에 중간에 끊겨버림.
  - 해결 : Attack 애니메이션 Setting의 Transition Duration을 0으로 만들어서 해결. 

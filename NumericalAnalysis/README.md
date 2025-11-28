## 概要

数値解析の学び直しのため、実装と整理を実施。

### 特徴

- **モンテカルロ法**:  
  乱数を用いて数値計算を行う手法

- **テイラー展開**:  
  関数を多項式で近似する手法

  ```math
  \begin{align}
    f(x) &= \sum_{n=0}^{\infty} \frac{f^{(n)}(a)}{n!}(x-a)^n \\ 
         &= f(a) + f'(a)(x-a) + \frac{f''(a)}{2!}(x-a)^2 + \frac{f'''(a)}{3!}(x-a)^3 + \dots
  \end{align}
  ```

- **マクローリン展開**:  
  関数を多項式で近似する手法  
  テイラー展開において、0を中心としたもの

  ```math
  \begin{align}
    f(x) &= \sum_{n=0}^{\infty} \frac{f^{(n)}(0)}{n!}x^n \\ 
         &= f(0) + f'(0)x + \frac{f''(0)}{2!}x^2 + \frac{f'''(0)}{3!}x^3 + \dots
  \end{align}
  ```

- **ニュートン法**:  
  方程式の解を近似する手法

  ```math
  \begin{align}
    x_{n+1} &= x_n - \frac{f(x_n)}{f'(x_n)}
  \end{align}
  ```

- **シンプソン法**:  
  定積分の解を近似する手法

  ```math
  \begin{align}
    \int_a^b f(x) dx &\approx \frac{h}{3} \left[ f(x_0) + 4 \sum_{i=1,3,5,\dots}^{n-1} f(x_i) + 2 \sum_{i=2,4,6,\dots}^{n-2} f(x_i) + f(x_n) \right]
  \end{align}
  ```

- **オイラー法**:  
  常微分方程式の解を近似する手法

  ```math
  \begin{align}
    y_{n+1} &= y_n + h f(x_n, y_n)
  \end{align}
  ```

- **ルンゲ・クッタ法**:  
  常微分方程式の解を高精度で近似する手法

  ```math
  \begin{align}
    y_{n+1} &= y_n + \frac{h}{6} (k_1 + 2 k_2 + 2 k_3 + k_4)
  \end{align}
  ```

  ```math
  \begin{align}
    \mathrm{where} \quad
    & k_1 &= f(x_n, y_n) \\ 
    & k_2 &= f \left(x_n + \frac{h}{2}, y_n + \frac{h}{2} k_1 \right) \\ 
    & k_3 &= f \left(x_n + \frac{h}{2}, y_n + \frac{h}{2} k_2 \right) \\ 
    & k_4 &= f(x_n + h, y_n + h k_3)
  \end{align}
  ```

- **ガウスの消去法**:  
  連立一次方程式を解く手法

  ```math
  \left[
    \begin{array}{cccc|c}
      a_{11} & a_{12} & \dots  & a_{1j} & b_1    \\ 
      a_{21} & a_{22} & \dots  & a_{2j} & b_2    \\ 
      \vdots & \vdots & \ddots & \vdots & \vdots \\ 
      a_{i1} & a_{i2} & \dots  & a_{ij} & b_i
    \end{array}
  \right]
  \to
  \left[
    \begin{array}{cccc|c}
      a'_{11} & a'_{12} & \dots  & a'_{1j} & b'_1   \\ 
              & a'_{22} & \dots  & a'_{2j} & b'_2   \\ 
              &         & \ddots & \vdots  & \vdots \\ 
              &         &        & a'_{ij} & b'_i
    \end{array}
  \right]
  \to
  \left[
    \begin{array}{c}
      b''_1  \\ 
      b''_2  \\ 
      \vdots \\ 
      b''_i
    \end{array}
  \right]
  ```

- **ガウス・ジョルダン法**:  
  連立一次方程式を解く手法  
  ガウスの消去法と比較して計算量が多いが、解が直接得られる

  ```math
  \left[
    \begin{array}{cccc|c}
      a_{11} & a_{12} & \dots  & a_{1j} & b_1    \\ 
      a_{21} & a_{22} & \dots  & a_{2j} & b_2    \\ 
      \vdots & \vdots & \ddots & \vdots & \vdots \\ 
      a_{i1} & a_{i2} & \dots  & a_{ij} & b_i
    \end{array}
  \right]
  \to
  \left[
    \begin{array}{cccc|c}
      1 &   &        &   & b'_1   \\ 
        & 1 &        &   & b'_2   \\ 
        &   & \ddots &   & \vdots \\ 
        &   &        & 1 & b'_i
    \end{array}
  \right]
  ```

- **その他**
  - **フィボナッチ数列**:  
    前の2つの数の和が次の数になる数列

    ```math
    F_n =
    \begin{cases}
      0               & (n=0) \\ 
      1               & (n=1) \\ 
      F_{n-1}+F_{n-2} & (n \geq 2)
    \end{cases}
    ```

  - **アッカーマン関数**:  
    与える数が大きくなると計算量が爆発的に増加する関数

    ```math
    A(m, n) =
    \begin{cases}
      n+1              & (m=0) \\ 
      A(m-1, 1)        & (n=0) \\ 
      A(m-1, A(m,n-1)) & (\mathrm{otherwise})
    \end{cases}
    ```
